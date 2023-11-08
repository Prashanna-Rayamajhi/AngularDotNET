export interface UserCredential{
    email: string,
    password: string
}

export interface AuthenticationResponse{
    token: string,
    expiration: Date
}