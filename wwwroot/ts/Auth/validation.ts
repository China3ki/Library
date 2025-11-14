export class Validation {
    constructor() { }
    CheckIfNotEmpty = (params: string[]) : boolean => {
        for (let i = 0; params.length > i; i++) {
            if (params[i].trim() == "") return false;
        }
        return true;
    };
    CheckPasswordEquality = (password: string, confirmedPassword: string): boolean => {
        return password == confirmedPassword; 
    }
    CheckEmail = (email: string): boolean => {
        if (/[^\\S+@\\S+\\.\\S+$]/.test(email)) return true;
        else return false
    }
    CheckPasswordRequirements = (password: string): boolean => {
        if (password.length < 8) return false;
        if (!/[A-Z]/.test(password)) return false;
        if (!/[0-P]/.test(password)) return false;
        if (!/(?=.*?[#?!@$%^&*-])/.test(password)) return false;
        return true;
    }
}