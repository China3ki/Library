import { Validation } from "./validation.js";
class Auth {
    constructor() {
        document.querySelector(".forms__submit.register")?.addEventListener("click", this.Register);
        document.querySelector(".forms__submit.login")?.addEventListener("click", this.Login);
    }
    validation: Validation = new Validation();

    Register = async (e : Event) => {
        e.preventDefault();
        const form: HTMLFormElement | null = document.querySelector('[data-form="register"]');

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
  
        if (validErrors.length > 0) {
            this.RenderError(validErrors);
            return;
        }


        const json: string = JSON.stringify(data.email);
        const fetchData = await fetch(`https://localhost:7051/api/AuthRegister/email/${data.email}`, {
            method: "POST",
            body: json,
            headers: {
                "Accept": "/",
                "Content-Type": "application/json"
            }
        })
        if (!fetchData.ok) {
            const res = await fetchData.text();
            console.log(res);
            this.RenderError([res]);
            return;
        }
        this.RenderInfo("Your account has been created!");
        setTimeout(() => {
            form.submit();
        }, 2000)
    }
    Login = async (e : Event) => {
        e.preventDefault();
        const validErrors: string[] = [];
        const form: HTMLFormElement | null = document.querySelector('[data-form="login"]');

        if (form == null) return;

        const data: AuthLogin = {
            loginEmail: form.loginEmail.value,
            loginPassword: form.loginPassword.value
        }
        if (!this.validation.CheckIfNotEmpty([data.loginEmail, data.loginPassword])) validErrors.push("One or more inputs are empty!");
        if (data.loginPassword.length < 8) validErrors.push("Wrong password!")
        if (validErrors.length > 0) {
            this.RenderError(validErrors);
            return;
        }
        const json: string = JSON.stringify(data);
        const fetchData = await fetch("https://localhost:7051/api/Auth/Login", {
            method: "POST",
            body: json,
            headers: {
                "Accept": "/",
                "Content-type": "application/json",
            }
        })

        if (!fetchData.ok) {
            const res = await fetchData.text();
            this.RenderError([res]);
            return
        }
        this.RenderInfo("Login succesful!");
        setTimeout(() => {
            form.submit();
        }, 2000);
    }


    RenderInfo = (info: string) => {
        const infoHTML: HTMLElement | null = document.querySelector(".forms__info");
        if (infoHTML == null) return;
        infoHTML.innerHTML = "";
        infoHTML.insertAdjacentHTML("beforeend", `<span class="forms__correct">${info}</span>`)
    }
    RenderError = (errors: string[]) => {
        const infoHTML: HTMLElement | null = document.querySelector(".forms__info");
        if (infoHTML == null) return;
        if (errors.length > 0) {
            infoHTML.innerHTML = "";
            errors.forEach(error => {
                infoHTML.insertAdjacentHTML("beforeend", `<span class="forms__error">${error}</span>`);
            });
            return;
        }
    }
}
interface AuthLogin {
    loginEmail: string,
    loginPassword: string
}
interface AuthRegister {
    nickname :string,
    email: string,
    password: string,
    confirmedPassword: string
}
const auth: Auth = new Auth();