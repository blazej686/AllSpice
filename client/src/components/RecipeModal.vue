<template>
    <div class="modal fade " id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
        aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog modal-fullscreen">
            <div class="modal-content">

                <div class="modal-body ">
                    <div class="text-end">
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div v-if="recipe" class="container-fluid">
                        <section class="row">
                            <div class="col-4">
                                <img class="img-fluid recipe" :src="recipe.img" alt="Recipe Image">
                            </div>
                            <div class="col-8">
                                <section class="row justify-content-around">
                                    <div class="col-12 d-flex justify-content-between">
                                        <h3>
                                            {{ recipe.title }}
                                        </h3>
                                        <p class="category-tag m-0 p-1">
                                            {{ recipe.category }}
                                        </p>
                                    </div>
                                    <div class="col-5 shadow p-0">
                                        <h4 class="bg-success rounded-top m-0">Recipe Instructions</h4>
                                        <div class="bg-primary rounded-bottom">
                                            {{ recipe.instructions }}
                                        </div>
                                    </div>
                                    <div class="col-5 shadow p-0">
                                        <h4 class="bg-success m-0">Recipe Ingredients</h4>
                                        <div v-for="ingredient in ingredients" :key="ingredient.id" class="bg-primary">
                                            {{ ingredient.quantity + ' ' + ingredient.name }}
                                        </div>
                                    </div>
                                    <div class="col-12 d-flex justify-content-around mt-2 ">
                                        <div>
                                            <button class="btn btn-outline-success">Edit Instructions</button>
                                        </div>
                                        <div>
                                            <button class="btn btn-outline-success">Edit Recipe</button>
                                            <div v-if="recipe.creatorId == account.id" class="text-end my-2">
                                                <button class="btn btn-outline-danger"><i class="mdi mdi-delete"></i>Delete
                                                    Recipe</button>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </section>

                    </div>
                </div>

            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.activeIngredients),
            account: computed(() => AppState.account),

        }
    }
};
</script>


<style lang="scss" scoped>
.recipe {
    height: 90dvh;
}

.category-tag {
    width: fit-content;
    background: rgba(17, 12, 12, 0.35);
    border-radius: 5px;
    box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
    backdrop-filter: blur(5.4px);
    -webkit-backdrop-filter: blur(5.4px);
    border: 1px solid rgba(255, 255, 255, 0.23);
}
</style>