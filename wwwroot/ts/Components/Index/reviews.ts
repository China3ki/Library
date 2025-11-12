class Reviews {
    constructor() {
        document.querySelector('.join__button--left')?.addEventListener("click", this.LeftReview);
        document.querySelector('.join__button--right')?.addEventListener("click", this.RightReview);
    }

    index: number = 1;

    RightReview = (e: Event) => {
        const reviewsHTML: NodeListOf<HTMLElement> = document.querySelectorAll(".join__review");
        const leftArrow: HTMLElement | null = document.querySelector(".join__button--left");
        if (leftArrow != null) leftArrow.classList.remove("hide");
        if (this.index == reviewsHTML.length - 1) return;
        reviewsHTML[this.index].classList.remove("show");
        reviewsHTML[this.index].classList.add("left");

        reviewsHTML[this.index + 1].classList.remove("right");
        reviewsHTML[this.index + 1].classList.add("show");

        if (this.index - 1 != -1) reviewsHTML[this.index - 1].classList.remove("left");


        if (this.index + 2 != reviewsHTML.length) reviewsHTML[this.index + 2].classList.add("right");
        this.index++;
        if (this.index == reviewsHTML.length - 1) {
            const rightArrow = e.target as HTMLElement;
            rightArrow.classList.add("hide");
        }
    }
     LeftReview = (e: Event) => {
        const reviewsHTML: NodeListOf<HTMLElement> = document.querySelectorAll(".join__review");
        const rightArrow: HTMLElement | null = document.querySelector(".join__button--right");

        if (rightArrow != null) rightArrow.classList.remove("hide");

        if (this.index == 0) return;

        reviewsHTML[this.index].classList.remove("show");
        reviewsHTML[this.index].classList.add("right");

        reviewsHTML[this.index - 1].classList.remove("left");
        reviewsHTML[this.index - 1].classList.add("show");

        if (this.index + 1 != reviewsHTML.length) reviewsHTML[this.index + 1].classList.remove("right");

        if (this.index - 2 != -1) reviewsHTML[this.index - 2].classList.add("left");
        this.index--;
        if (this.index == 0) {
            const leftArrow = e.target as HTMLElement;
            leftArrow.classList.add("hide");
        }
    }

}
const review: Reviews = new Reviews();