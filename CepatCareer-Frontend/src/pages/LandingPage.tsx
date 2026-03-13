import { Layout } from "antd"
import { Header } from "antd/es/layout/layout"
import axios from "axios"
import { useEffect, useState } from "react"
import JobsCard from "../components/JobsCards"

type jobs = {
    applicants?: string,
    dateCreated: string,
    description: string,
    fileRequirements: string,
    id: number,
    jobId: string,
    roles: string,
    title: string,
}

function LandingPage(){
    const [search, setSearch] = useState("")
    const [jobs, setJobs] = useState<jobs[]>([])
    const HandleSubmitSearch = () => {
        console.log(search)
    }

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const res = await axios.get("http://localhost:5221/api/Jobs/GetJobs")
                setJobs(res.data.data)
            } catch (error) {
                console.log(error)
            }
        }
        fetchJobs()
    },[])

    return(
        <Layout className="h-dvh">
            <Header className="h-fit! text-center p-14!">
                <h1 className="font-bold text-4xl text-white">C Career</h1>
                <form onSubmit={(e) => {
                    e.preventDefault()
                    HandleSubmitSearch()
                }}>
                    <input type="text"
                        placeholder="Search Jobs..."
                        className="border w-2xl h-11 m-4 p-3 text-[1.2rem] rounded-4xl bg-white"
                        onChange={(e) => setSearch(e.target.value)}
                    />
                </form>
            </Header>
            <Layout className="p-4">
                <h1 className="text-3xl font-medium">Available Jobs</h1>
                {
                    jobs.map(job => {
                        return <JobsCard
                            key={job.jobId}
                            title={job.title}
                            dateCreated={job.dateCreated}
                            roles={JSON.parse(job.roles)}
                            description={job.description}
                        />
                    })
                }
            </Layout>
        </Layout>
    )
}
export default LandingPage