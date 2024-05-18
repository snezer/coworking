
export type Token = string
export interface ITokensAuth {
    accessToken: Token,
    refreshToken: Token,
    expRefreshSec: number
}
