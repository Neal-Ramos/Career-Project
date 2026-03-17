import { useQuery } from "@tanstack/react-query"
import { fetchJobs, fetchJobsById } from "../API/Jobs"
import type { IJob } from "../global/IJobs"


export const useJobs = (Page: number, PageSize: number) => {
    return useQuery<IJob[]>({
        queryKey: ["Jobs"],
        queryFn: () => fetchJobs(Page, PageSize),
        staleTime: 1000 * 60 * 5,
        refetchOnWindowFocus: false,
    })
}
export const useJobsById = (jobGuid: string) => {
    return useQuery<IJob>({
        queryKey: ["jobById", jobGuid],
        queryFn: () => fetchJobsById(jobGuid),
        staleTime: 1000 * 60 * 5,
        refetchOnWindowFocus: false,
    })
}