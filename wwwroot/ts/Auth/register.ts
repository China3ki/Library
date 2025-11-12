import { Validation } from "./validation.js";
class Auth {
    constructor() {
        document.querySelector(".forms__submit.register")?.addEventListener("click", this.Register);
    }
    validation: Validation = new Validation();
    Register = async (e : Event) => {
        e.preventDefault();
        const form: HTMLFormElement | null = document.querySelector('[data-form="register"]');
        const errors: HTMLElement | null = document.querySelector(".forms__errors");
        const validErrors: string[] = [];

        if (form == null) return;
        const data: AuthRegister = {
            nickname: form.nickname.value,
            email: form.email.value,
            password: form.password.value,
            confirmedPassword: form.confirmedPassword.value
        }
        if (!this.validation.CheckIfNotEmpty([data.nickname, data.email, data.password, data.confirmedPassword])) validErrors.push("One or more inputs are empty!");
        if (!this.validation.CheckPasswordEquality(data.password, data.confirmedPassword)) validErrors.push("Passwords are not the same!");
        if (!this.validation.CheckEmail(data.email)) validErrors.push("Email is not correct!");
        if (!this.validation.CheckPasswordRequirements(data.password)) validErrors.push("Password does not meet the requirements!")
        if (errors == null) return;
        errors.innerHTML = "";
        if (validErrors.length > 0) {
            validErrors.forEach(error => {
                errors.insertAdjacentHTML("beforeend", `<span class="forms__error">${error}</span>`)
            })
            return;
        }



        const json: string = JSON.stringify(data);
        const fetchData = await fetch("https://localhost:7051/api/AuthRegister/register", {
            method: "POST",
            body: json,
            headers: {
                "Accept": "/",
                "Content-Type": "application/json"
            }
        })
        const res = await fetchData.text();
        if (!fetchData.ok) {
            errors.insertAdjacentHTML("beforeend", `<span class="forms__error">${res}</span>`)
        }
    }
    RenderError = () => {

    }
}
interface AuthRegister {
    nickname :string,
    email: string,
    password: string,
    confirmedPassword: string
}
const auth: Auth = new Auth();