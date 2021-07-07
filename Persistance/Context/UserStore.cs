//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Domain.Entities.Auth;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace Persistance.Context
//{

//    public class UserStore : IUserStore<APIUser>, IUserPasswordStore<APIUser>
//    {
//        private readonly ApplicationDbContext db;

//        public UserStore(ApplicationDbContext db)
//        {
//            this.db = db;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db?.Dispose();
//            }
//        }

//        public Task<string> GetUserIdAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.Id.ToString());
//        }

//        public Task<string> GetUserNameAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.UserName);
//        }

//        public Task SetUserNameAsync(APIUser user, string userName, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException(nameof(SetUserNameAsync));
//        }

//        public Task<string> GetNormalizedUserNameAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException(nameof(GetNormalizedUserNameAsync));
//        }

//        public Task SetNormalizedUserNameAsync(APIUser user, string normalizedName, CancellationToken cancellationToken)
//        {
//            return Task.FromResult((object)null);
//        }

//        public async Task<IdentityResult> CreateAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            db.Add(user);

//            await db.SaveChangesAsync(cancellationToken);

//            return await Task.FromResult(IdentityResult.Success);
//        }

//        public Task<IdentityResult> UpdateAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException(nameof(UpdateAsync));
//        }

//        public async Task<IdentityResult> DeleteAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            db.Remove(user);

//            int i = await db.SaveChangesAsync(cancellationToken);

//            return await Task.FromResult(i == 1 ? IdentityResult.Success : IdentityResult.Failed());
//        }

//        public async Task<APIUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
//        {
//            if (int.TryParse(userId, out int id))
//            {
//                return await db.Users.FindAsync(id);
//            }
//            else
//            {
//                return await Task.FromResult((APIUser)null);
//            }
//        }

//        public async Task<APIUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
//        {
//            return await db.Users                
//                .SingleOrDefaultAsync(p => p.UserName.Equals("dev"), cancellationToken);
//        }

//        public Task SetPasswordHashAsync(APIUser user, string passwordHash, CancellationToken cancellationToken)
//        {
//            user.PasswordHash = passwordHash;

//            return Task.FromResult((object)null);
//        }

//        public Task<string> GetPasswordHashAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.PasswordHash);
//        }

//        public Task<bool> HasPasswordAsync(APIUser user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
//        }
//    }
//}
