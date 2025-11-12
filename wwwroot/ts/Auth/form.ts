class Forms {
    constructor() {
        document.querySelectorAll(".forms__option").forEach(el => el.addEventListener("click", this.ChangeForm))
        document.querySelector(".forms__close")?.addEventListener("click", this.CloseForm);
        document.querySelectorAll("[data-open]").forEach(el => el.addEventListener("click", this.OpenForm));
    }
    ChangeForm = (e: Event) => {
        const forms: NodeListOf<HTMLElement> = document.querySelectorAll(".forms__form");
        const target: HTMLElement = e.target as HTMLElement;
        const data: string | undefined = target.dataset.option;
        const requirements: HTMLElement | null = document.querySelector(".forms__requirements");
        const errors: HTMLElement | null = document.querySelector(".forms__errors");
        if (data == undefined) return;
        for (const form of forms) {
            if (form == null) return;
            if (form.dataset.form == data) form.classList.add("show");
            else form.classList.remove("show");
        }
        if (requirements == null) return;
        if (data == "register") requirements.classList.add("show");
        else requirements.classList.remove("show");

        if (errors == null) return;
        if (data == "register") errors.classList.add("show");
        else errors.classList.remove("show");


        document.querySelectorAll(".forms__option").forEach(el => {
            el.classList.remove('show');
        })
        target.classList.add("show");
    }
    CloseForm = () => {
        const forms: HTMLElement | null = document.querySelector(".forms");
        if (forms == null) return;
        forms.classList.remove("show");
    }
    OpenForm = () => {
        const forms: HTMLElement | null = document.querySelector(".forms");
        if (forms == null) return;
        forms.classList.add("show");
    }
}
const forms: Forms = new Forms();