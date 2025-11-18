var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { Validation } from "./validation.js";
class Auth {
    constructor() {
        var _a, _b;
        this.validation = new Validation();
        this.Register = (e) => __awaiter(this, void 0, void 0, function* () {
            e.preventDefault();
            const form = document.querySelector('[data-form="register"]');
            const validErrors = [];
            if (form == null)
                return;
            const data = {
                nickname: form.nickname.value,
                email: form.email.value,
                password: form.password.value,
                confirmedPassword: form.confirmedPassword.value
            };
            if (!this.validation.CheckIfNotEmpty([data.nickname, data.email, data.password, data.confirmedPassword]))
                validErrors.push("One or more inputs are empty!");
            if (!this.validation.CheckPasswordEquality(data.password, data.confirmedPassword))
                validErrors.push("Passwords are not the same!");
            if (!this.validation.CheckEmail(data.email))
                validErrors.push("Email is not correct!");
            if (!this.validation.CheckPasswordRequirements(data.password))
                validErrors.push("Password does not meet the requirements!");
            if (validErrors.length > 0) {
                this.RenderError(validErrors);
                return;
            }
            const json = JSON.stringify(data.email);
            const fetchData = yield fetch(`https://localhost:7051/api/Auth/email/${data.email}`, {
                method: "POST",
                body: json,
                headers: {
                    "Accept": "/",
                    "Content-Type": "application/json"
                }
            });
            if (!fetchData.ok) {
                const res = yield fetchData.text();
                this.RenderError([res]);
                return;
            }
            this.RenderInfo("Your account has been created!");
            setTimeout(() => {
                form.submit();
            }, 1000);
        });
        this.Login = (e) => __awaiter(this, void 0, void 0, function* () {
            e.preventDefault();
            const validErrors = [];
            const form = document.querySelector('[data-form="login"]');
            if (form == null)
                return;
            const data = {
                loginEmail: form.loginEmail.value,
                loginPassword: form.loginPassword.value
            };
            if (!this.validation.CheckIfNotEmpty([data.loginEmail, data.loginPassword]))
                validErrors.push("One or more inputs are empty!");
            if (data.loginPassword.length < 8)
                validErrors.push("Wrong password!");
            if (validErrors.length > 0) {
                this.RenderError(validErrors);
                return;
            }
            const json = JSON.stringify(data);
            const fetchData = yield fetch("https://localhost:7051/api/Auth/Login", {
                method: "POST",
                body: json,
                headers: {
                    "Accept": "/",
                    "Content-type": "application/json",
                }
            });
            if (!fetchData.ok) {
                const res = yield fetchData.text();
                this.RenderError([res]);
                return;
            }
            this.RenderInfo("Login succesful!");
            setTimeout(() => {
                form.submit();
            }, 1000);
        });
        this.RenderInfo = (info) => {
            const infoHTML = document.querySelector(".forms__info");
            if (infoHTML == null)
                return;
            infoHTML.innerHTML = "";
            infoHTML.insertAdjacentHTML("beforeend", `<span class="forms__correct">${info}</span>`);
        };
        this.RenderError = (errors) => {
            const infoHTML = document.querySelector(".forms__info");
            if (infoHTML == null)
                return;
            if (errors.length > 0) {
                infoHTML.innerHTML = "";
                errors.forEach(error => {
                    infoHTML.insertAdjacentHTML("beforeend", `<span class="forms__error">${error}</span>`);
                });
                return;
            }
        };
        (_a = document.querySelector(".forms__submit.register")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", this.Register);
        (_b = document.querySelector(".forms__submit.login")) === null || _b === void 0 ? void 0 : _b.addEventListener("click", this.Login);
    }
}
const auth = new Auth();
//# sourceMappingURL=auth.js.map