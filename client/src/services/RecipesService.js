import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
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

    }
}
export const recipesService = new RecipesService()