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
                                <section class="row">
                                    <div class="col-12 d-flex justify-content-between">
                                        <h3>
                                            {{ recipe.title }}
                                        </h3>
                                        <p class="category-tag m-0 p-1">
                                            {{ recipe.category }}

                                        </p>
                                    </div>
                                    <div class="col-6">
                                        {{ recipe.instructions }}
                                    </div>
                                    <div class="col-6">
                                        {{ recipe.ingredients }}
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
import { Recipe } from '../models/Recipe.js';
export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe)
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