using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RexipeMobile.Models;
using RexipeModels;

namespace RexipeMobile.Controllers
{
    [Route("api/recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Recipe>> List()
        {
            return _recipeRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            Recipe recipe = _recipeRepository.Get(id);

            if (recipe == null)
                return NotFound();

            return recipe;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Recipe> Create([FromBody]Recipe recipe)
        {
            _recipeRepository.Add(recipe);
            return CreatedAtAction(nameof(GetRecipe), new { recipe.Id }, recipe);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Recipe recipe)
        {
            try
            {
                _recipeRepository.Update(recipe);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            Recipe recipe = _recipeRepository.Remove(id);

            if (recipe == null)
                return NotFound();

            return Ok();
        }
    }
}
