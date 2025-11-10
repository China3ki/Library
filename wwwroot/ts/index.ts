let lastScroll: number = 0;
const HideHeaderNav = (e: WheelEvent) => {
    const header : HTMLElement | null = document.querySelector(".header");
    if (header != null) {
        if (e.deltaY > 0) header.classList.add("active");
        else if (e.deltaY < 0) header.classList.remove("active"); 
    }
}