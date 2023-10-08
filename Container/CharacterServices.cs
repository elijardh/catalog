using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Models;
using catalog.Services;

namespace catalog.Container
{
    public class CharacterServices : ICharacterServices


    {
        private static List<Character> characters = new List<Character>{
                new(),
                new(){
                    Id = 1,
                    Name="Sam"},
                new(){
                      Id = 2,
                    Name="Drake"},
                new(){
                      Id = 3,
                    Name="Gandalf"},
                new(){
                      Id = 4,
                    Name="Kurapika"},

            };

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(character);

            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            var serviceResponse = new ServiceResponse<Character>();

            if (character is not null)
            {
                serviceResponse.Data = character;
                return serviceResponse;
            }

            serviceResponse.Data = character;
            serviceResponse.Success = false;
            serviceResponse.Message = "Not Found";

            return serviceResponse;
        }
    }
}