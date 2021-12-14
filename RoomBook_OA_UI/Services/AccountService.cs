using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace RoomBook_OA_UI.Services
{
    public interface IAccountService
    {
        User User { get; }
        Task Initialize();
        Task Login(UserForAuthenticationDto model);
        Task Logout();
        Task Register(UserForRegistrationDto model);
        Task<IList<User>> GetAll();
        Task<User> GetById(string id);
        Task Update(string id, UserForEditDto model);
        Task Delete(string id);
    }

    public class AccountService : IAccountService
    {
        private readonly IHttpService _httpService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;
        private readonly string _userKey = "user";

        public User User { get; private set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>(_userKey);
        }

        public async Task Login(UserForAuthenticationDto model)
        {
            User = await _httpService.Post<User>("/api/v1/authentication/login", model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("/api/v1/authentication/login");
        }

        public async Task Register(UserForRegistrationDto model)
        {
            await _httpService.Post("/api/v1/authentication", model);
        }

        public async Task<IList<User>> GetAll()
        {
            return await _httpService.Get<IList<User>>("/api/v1/authentication");
        }

        public async Task<User> GetById(string id)
        {
            return await _httpService.Get<User>($"/api/v1/authentication/{id}");
        }

        public async Task Update(string id, UserForEditDto model)
        {
            await _httpService.Put($"/api/v1/authentication/{id}", model);

            // update stored user if the logged in user updated their own record
            if (id == User.Id) 
            {
                // update local storage
                User.FirstName = model.FirstName;
                User.LastName = model.LastName;
                User.UserName = model.UserName;
                await _localStorageService.SetItem(_userKey, User);
            }
        }

        public async Task Delete(string id)
        {
            await _httpService.Delete($"/api/v1/authentication/{id}");

            // auto logout if the logged in user deleted their own record
            if (id == User.Id)
                await Logout();
        }
    }
}