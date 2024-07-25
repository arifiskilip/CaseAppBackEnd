using Application.Features.Auth.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
	public class AuthBusinessRules : BaseBusinessRules
	{
		private readonly IUserRepository _userRepository;

		public AuthBusinessRules(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> UserEmailCheck(string email)
		{
			var user = await _userRepository.GetAsync(x => x.Email.ToLower() == email.ToLower());
			if (user is null) throw new BusinessException(AuthMessages.UserNotFound);
			return user;
		}
		public void IsPasswordCorrectWhenLogin(User user, string password)
		{
			var check = HashingHelper.VerifyPasswordHash(password: password, passwordHash: user.PasswordHash, passwordSalt: user.PasswordSalt);
			if (!check) throw new BusinessException(AuthMessages.UserEmailNotFound);
		}

	}
}
