"use strict";
class Forms {
    constructor() {
        var _a;
        this.ChangeForm = (e) => {
            const forms = document.querySelectorAll(".forms__form");
            const target = e.target;
            const data = target.dataset.option;
            const requirements = document.querySelector(".forms__requirements");
            const errors = document.querySelector(".forms__errors");
            if (data == undefined)
                return;
            for (const form of forms) {
                if (form == null)
                    return;
                if (form.dataset.form == data)
                    form.classList.add("show");
                else
                    form.classList.remove("show");
            }
            if (requirements == null)
                return;
            if (data == "register")
                requirements.classList.add("show");
            else
                requirements.classList.remove("show");
            if (errors == null)
                return;
            if (data == "register")
                errors.classList.add("show");
            else
                errors.classList.remove("show");
            document.querySelectorAll(".forms__option").forEach(el => {
                el.classList.remove('show');
            });
            target.classList.add("show");
        };
        this.CloseForm = () => {
            const forms = document.querySelector(".forms");
            if (forms == null)
                return;
            forms.classList.remove("show");
        };
        this.OpenForm = () => {
            const forms = document.querySelector(".forms");
            if (forms == null)
                return;
            forms.classList.add("show");
        };
        document.querySelectorAll(".forms__option").forEach(el => el.addEventListener("click", this.ChangeForm));
        (_a = document.querySelector(".forms__close")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", this.CloseForm);
        document.querySelectorAll("[data-open]").forEach(el => el.addEventListener("click", this.OpenForm));
    }
}
const forms = new Forms();
//# sourceMappingURL=form.js.map