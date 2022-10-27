export interface IUnidades {
    id:number;
    apelido:string;
    local:string;
    marca:string;
    modelo:string;
    isActive:boolean;
}

export interface IGeracao {
    id:number;
    data:string;
    kw:number;
    unidadeId:number;
}

export interface ILogin {
    email:string;
    password:string;
}

export interface IUser {
    id:number;
    nome:string;
    email:string;
    password:string;
    role:number
}

