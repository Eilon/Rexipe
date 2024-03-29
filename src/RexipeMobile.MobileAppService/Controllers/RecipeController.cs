﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RexipeMobile.Models;
using RexipeModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RexipeMobile.Controllers
{
    [Route("api/recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeRepository _recipeRepository;

        public RecipeController(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
        {
            return (await _recipeRepository.GetAll()).ToList();
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Recipe>> GetRecipe(int recipeId)
        {
            var recipe = await _recipeRepository.GetRecipe(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpGet("{recipeId}/ingredients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<IngredientQuantity>>> GetRecipeIngredients(int recipeId)
        {
            var ingredients = await _recipeRepository.GetRecipeIngredients(recipeId);

            if (ingredients == null)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        [HttpGet("{recipeId}/directions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<IngredientQuantity>>> GetRecipeDirections(int recipeId)
        {
            var directions = await _recipeRepository.GetRecipeDirections(recipeId);

            if (directions == null)
            {
                return NotFound();
            }

            return Ok(directions);
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<Recipe>> Create([FromBody]Recipe recipe)
        //{
        //    await _recipeRepository.Add(recipe);
        //    return CreatedAtAction(nameof(GetRecipe), new { recipe.Id }, recipe);
        //}

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Edit([FromBody] Recipe recipe)
        //{
        //    try
        //    {
        //        await _recipeRepository.Update(recipe);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error while creating");
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var recipe = await _recipeRepository.Remove(id);

        //    if (recipe == null)
        //        return NotFound();

        //    return Ok();
        //}
    }
}
