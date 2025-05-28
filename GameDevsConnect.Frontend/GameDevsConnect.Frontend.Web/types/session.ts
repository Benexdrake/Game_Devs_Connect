import { UserType } from "./user"

export type SessionType =
{
    user:UserType,
    expires:string,
    accessToken:string
}