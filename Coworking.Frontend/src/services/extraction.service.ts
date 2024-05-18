function extract<T>(apiResponse:any):T{
    return apiResponse?.data
}

export default {
    extract
}
