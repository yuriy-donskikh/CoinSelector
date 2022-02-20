import { User } from "../models/user";
import { UserInfo } from "../models/user-info";

export interface SelectorState {
    users: UserInfo[],
    activeUser: User | null,
    error: string
}