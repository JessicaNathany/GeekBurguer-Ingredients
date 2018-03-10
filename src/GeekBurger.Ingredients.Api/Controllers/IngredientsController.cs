﻿using GeekBurger.Ingredients.Api.Data;
using GeekBurger.Ingredients.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeekBurger.Ingredients.Api.Controllers
{
    [Route("products/{productId}/ingredients")]
    public class IngredientsController : Controller
    {
        private readonly MockRepository _mockRepository;

        public IngredientsController(MockRepository mockRepository)
        {
            _mockRepository = mockRepository;
        }

        [HttpGet()]
        public IActionResult Get(Guid productId)
        {
            var ingredients = _mockRepository.GetIngredients(productId);

            return Ok(ingredients);
        }

        [HttpGet("{ingredientId}", Name = "GetIngredient")]
        public IActionResult Get(Guid productId, Guid ingredientId)
        {
            var ingredients = _mockRepository.GetIngredient(productId, ingredientId);

            return Ok(ingredients);
        }

        [HttpPost()]
        public IActionResult Create(Guid productId, [FromBody] Product request)
        {
            var ingredient = _mockRepository.Create(productId, request);

            return Created($"http://{Request.Host.Value}/products/{productId}/ingredients/{ingredient.Id}", ingredient);
        }

        [HttpPut("{ingredientId}")]
        public IActionResult Update(Guid productId, Guid ingredientId, [FromBody] Product request)
        {
            var ingredient = _mockRepository.Update(productId, ingredientId, request);

            return NoContent();
        }

        [HttpDelete("{ingredientId}")]
        public IActionResult Delete(Guid productId, Guid ingredientId)
        {
            return NoContent();
        }
    }
}