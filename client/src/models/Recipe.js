export class Recipe {
    constructor(data) {
        this.id = data.id
        this.title = data.title
        this.img = data.img
        this.instructions = data.instructions
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator

    }
}