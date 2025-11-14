export class Validation {
    constructor() {
        this.CheckIfNotEmpty = (params) => {
            for (let i = 0; params.length > i; i++) {
                if (params[i].trim() == "")
                    return false;
            }
            return true;
        };
        this.CheckPasswordEquality = (password, confirmedPassword) => {
            return password == confirmedPassword;
        };
        this.CheckEmail = (email) => {
            if (/[^\\S+@\\S+\\.\\S+$]/.test(email))
                return true;
            else
                return false;
        };
        this.CheckPasswordRequirements = (password) => {
            if (password.length < 8)
                return false;
            if (!/[A-Z]/.test(password))
                return false;
            if (!/[0-P]/.test(password))
                return false;
            if (!/(?=.*?[#?!@$%^&*-])/.test(password))
                return false;
            return true;
        };
    }
}
//# sourceMappingURL=validation.js.map