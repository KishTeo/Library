﻿using LibDB.Interfaces;
using LibDB.models;
using LibLogic.DTOs;
using AutoMapper;
using LibLogic.Interfaces;

namespace LibLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersWithRentsAsync()
        {
            var users = await _userRepository.GetAllAsync(u => u.Bookrental);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var addedUser = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDTO>(addedUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.UpdateAsync(user);
        }
        
    }
}