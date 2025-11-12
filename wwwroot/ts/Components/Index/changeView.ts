class ChangeView {
    constructor() {
        document.querySelectorAll(".join__item").forEach(el => el.addEventListener("click", this.Change));
    }
    Change = (e: Event) => {
        const target: HTMLElement = e.target as HTMLElement;
        const data: string | undefined = target.dataset.window;
        const windows: NodeListOf<HTMLElement> = document.querySelectorAll(".join__data");
        console.log("a");
        for (const window of windows) {
            window.classList.remove("show");
            if (window.dataset.window == data) window.classList.add("show");
        }
        document.querySelector(".join__item.active")?.classList.remove("active");
        target.classList.add("active");
    }
}
const changeView: ChangeView = new ChangeView();