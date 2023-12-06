<template>
  <div class="container-fluid p-5">
    <section class="row cover-photo justify-content-center align-items-center">
      <div class="col-5 text-center text-white fw-bold text-shadow">
        <h2 class="pt-2 m-0">All Spice</h2>
        <p class="m-0">Cherish Your Family</p>
        <p class="m-0">And Their Cooking</p>
      </div>
      <div class="col-8 d-flex justify-content-around glass-box rounded align-items-center py-2">
        <p class="m-0 p-2 glass-box">All</p>
        <p class="m-0 p-2 glass-box">My Recipes</p>
        <p class="m-0 p-2 glass-box">Favorites</p>
      </div>
    </section>
    <!-- 
    <button @click="changeType('')" class='btn btn-outline-dark my-1 p-1'>all</button>
          <button @click="changeType(type)" v-for="type in types" :key="type" class='btn btn-outline-dark my-1 p-1'>
            {{ type }}
          </button> -->

    <section class="row">
      <div class="col-4  p-5" v-for="recipe in  recipes " :key="recipe.id">


        <div class="p-2 rounded border " @click="setActive(recipe.id)" data-bs-toggle="modal"
          data-bs-target="#staticBackdrop" type="button"
          :style="{ backgroundImage: `url('${recipe.img}')`, backgroundSize: 'cover', backgroundPosition: 'center', height: '30dvh' }">
          <div class="text-end">
            <i v-if="isFav" class="mdi mdi-heart color-danger glass-box"></i>
            <i v-else class="mdi mdi-heart-outline glass-box"></i>
          </div>
          <div>
            <p class="category-tag p-1">
              {{ recipe.category }}
            </p>
          </div>
          <div class="d-flex ">
            <h3 class="title-tag p-1">{{ recipe.title }}</h3>
          </div>
        </div>
      </div>
    </section>
  </div>
  <RecipeModal :recipe="activeRecipe" />
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js';

export default {
  setup(recipe) {
    // const filteredType = ref("all");
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      // filteredType,
      recipes: computed(() => AppState.recipes),
      favorites: computed(() => AppState.favorites),
      isFav: computed(() => {
        const foundFav = AppState.favorites.find(favorite => favorite.favoriteId == recipe.id);
        if (!foundFav) {
          return false;
        }
        return true;
      }),
      filteredRecipes: computed(() => {
        if (filteredRecipes.value) {
          return AppState.recipes.filter((recipe) => recipe.creatorId == account.id);
        }
        else if (filteredRecipes.value == "favorites") {
          return AppState.favorites;
        }
        else
          return AppState.recipes;
      }),
      async setActive(recipeId) {
        try {
          await recipesService.setActive(recipeId);
        }
        catch (error) {
          Pop.error(error);
        }
      }
    };
  },
}
</script>

<style scoped lang="scss">
.cover-photo {
  height: 35vh;
  background-size: cover;
  background-position: center;
  border-radius: 15px;
  background-image: url(https://images.unsplash.com/photo-1466637574441-749b8f19452f?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
}

.glass-box {
  background: rgba(255, 255, 255, 0.35);
  border-radius: 5px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(5.4px);
  -webkit-backdrop-filter: blur(5.4px);
  border: 1px solid rgba(255, 255, 255, 0.23);
}

.category-tag {
  width: fit-content;
  background: rgba(255, 255, 255, 0.35);
  border-radius: 5px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(5.4px);
  -webkit-backdrop-filter: blur(5.4px);
  border: 1px solid rgba(255, 255, 255, 0.23);
}

.title-tag {
  width: fit-content;
  background: rgba(255, 255, 255, 0.35);
  border-radius: 5px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(5.4px);
  -webkit-backdrop-filter: blur(5.4px);
  border: 1px solid rgba(255, 255, 255, 0.23);
}
</style>
