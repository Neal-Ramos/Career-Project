import { useMutation } from "@tanstack/react-query"
import { addApplication } from "../API/JobApplications"


export const AddApplication = () => {
    return useMutation({
        mutationFn: addApplication
    }) 
}