export class AppConstants {

    public static get baseServidor():String{
        return "https://localhost:7268/api/"
    };

    public static get baseLogin():string{
        return this.baseServidor + "Autenticacao/login"
    };

    public static get baseUsers():string{
        return this.baseServidor + "Users"
    }
}
