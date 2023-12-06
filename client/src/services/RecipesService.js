import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {

    async getRecipes() {
        const res = await api.get('api/recipes')
        const recipes = res.data.map(recipe => new Recipe(recipe))
        AppState.recipes = recipes
    }

    async setActive(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}`)
        const recipeData = new Recipe(res.data)
        AppState.activeRecipe = recipeData
        this.setActiveIngredients(recipeId)

    }

    async setActiveIngredients(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        const ingredientData = res.data.map(ingedients => new Ingredient(ingedients))
        logger.log(ingredientData)
        AppState.activeIngredients = ingredientData
    }
}
export const recipesService = new RecipesService()