import axios from "axios"

export const addApplication = async (formData: any) => {
    const res = await axios.post(`${import.meta.env.VITE_API_URL}/AddApplication`, formData, {
        headers:{
            "Content-Type": "multipart/form-data"
        }
    })
    return res.data
}