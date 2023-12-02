<template>
  <div class="container-fluid p-5">
    <section class="row cover-photo justify-content-center align-items-center">
      <div class="col-5 text-center text-white fw-bold text-shadow">
        <h2 class="pt-2 m-0">All Spice</h2>
        <p class="m-0">Cherish Your Family</p>
        <p class="m-0">And Their Cooking</p>
      </div>
      <div class="col-8 d-flex justify-content-around bg-light rounded align-items-center py-2">
        <p class="m-0 p-2 card">All</p>
        <p class="m-0 p-2 card">My Recipes</p>
        <p class="m-0 p-2 card">Favorites</p>
      </div>
    </section>
    <section class="row">
      <div class="col-4  p-5" v-for="recipe in recipes" :key="recipe.id">
        <!-- <RouterLink>

        </RouterLink> -->
        <div class="p-2 rounded border">
          <div class="text-end">
            <i class="mdi mdi-heart-outline"></i>
            <i class="mdi mdi-heart color-danger"></i>
          </div>
          <div>
            <p>
              {{ recipe.category }}
            </p>
          </div>
          <div>
            <h3>{{ recipe.title }}</h3>

          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js'

export default {
  setup() {

    onMounted(() => {
      getRecipes();
    });

    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
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
</style>
