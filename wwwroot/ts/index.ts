let lastScroll: number = 0;
const HideHeaderNav = (e: WheelEvent) => {
    const header : HTMLElement | null = document.querySelector(".header");
    if (header != null) {
        if (e.deltaY > 0) header.classList.add("active");
        else if (e.deltaY < 0) header.classList.remove("active"); 
    }
}
let index : number = 1;
const RightReview = (e : Event) => {
    const reviewsHTML: NodeListOf<HTMLElement> = document.querySelectorAll(".join__review");
    const leftArrow: HTMLElement | null = document.querySelector(".join__button--left");
    if (leftArrow != null) leftArrow.classList.remove("hide");

    if (index == reviewsHTML.length - 1) return;
    reviewsHTML[index].classList.remove("show");
    reviewsHTML[index].classList.add("left");

    reviewsHTML[index + 1].classList.remove("right");
    reviewsHTML[index + 1].classList.add("show");

    if (index - 1 != -1) reviewsHTML[index - 1].classList.remove("left");


    if (index + 2 != reviewsHTML.length) reviewsHTML[index + 2].classList.add("right");
    index++;
    if (index == reviewsHTML.length - 1) {
        const rightArrow = e.target as HTMLElement;
        rightArrow.classList.add("hide");
    }
}

const LeftReview = (e : Event) => {
    const reviewsHTML: NodeListOf<HTMLElement> = document.querySelectorAll(".join__review");
    const rightArrow: HTMLElement | null = document.querySelector(".join__button--right");

    if (rightArrow != null) rightArrow.classList.remove("hide");

    if (index == 0) return;
    
    reviewsHTML[index].classList.remove("show");
    reviewsHTML[index].classList.add("right");

    reviewsHTML[index - 1].classList.remove("left");
    reviewsHTML[index - 1].classList.add("show");

    if (index + 1 != reviewsHTML.length) reviewsHTML[index + 1].classList.remove("right");

    if (index - 2 != -1) reviewsHTML[index - 2].classList.add("left");
    index--;
    if (index == 0) {
        const leftArrow = e.target as HTMLElement;
        leftArrow.classList.add("hide");
    }
}
const ChangeWindow = (e : Event) => {
    const target : HTMLElement = e.target as HTMLElement;
    const data: string | undefined = target.dataset.window;
    const windows: NodeListOf<HTMLElement> = document.querySelectorAll(".join__data");

    for (const window of windows) {
        window.classList.remove("show");
        if (window.dataset.window == data) window.classList.add("show");
    }
    document.querySelector(".join__item.active")?.classList.remove("active");
    target.classList.add("active");
}



document.querySelector('.join__button--left')?.addEventListener("click", LeftReview);
document.querySelector('.join__button--right')?.addEventListener("click", RightReview);
document.querySelectorAll(".join__item").forEach(el => el.addEventListener("click", ChangeWindow));