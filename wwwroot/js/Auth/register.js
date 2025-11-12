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
        var _a;
        this.validation = new Validation();
        this.Register = (e) => __awaiter(this, void 0, void 0, function* () {
            e.preventDefault();
            const form = document.querySelector('[data-form="register"]');
            const errors = document.querySelector(".forms__errors");
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
            if (errors == null)
                return;
            errors.innerHTML = "";
            if (validErrors.length > 0) {
                validErrors.forEach(error => {
                    errors.insertAdjacentHTML("beforeend", `<span class="forms__error">${error}</span>`);
                });
                return;
            }
            const json = JSON.stringify(data);
            const fetchData = yield fetch("https://localhost:7051/api/AuthRegister/register", {
                method: "POST",
                body: json,
                headers: {
                    "Accept": "/",
                    "Content-Type": "application/json"
                }
            });
            const res = yield fetchData.text();
            if (!fetchData.ok) {
                errors.insertAdjacentHTML("beforeend", `<span class="forms__error">${res}</span>`);
            }
        });
        this.RenderError = () => {
        };
        (_a = document.querySelector(".forms__submit.register")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", this.Register);
    }
}
const auth = new Auth();
//# sourceMappingURL=register.js.map