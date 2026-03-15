import { Col, Empty, Layout, Row } from "antd"
import JobsCard from "../components/JobsCards"
import LandingHero from "../components/LandingHero"
import { useJobs } from "../Hooks/useJobs"

function LandingPage(){
    const { data, isLoading, isError, error } = useJobs(1, 4)
    return(
        <Layout>
            <LandingHero/>
            <Layout className="max-w-4xl! mx-auto! px-6! py-16! w-full! min-h-dvh!">
                <div className="mb-10 text-center">
                    <h2 className="text-3xl font-black text-slate-900 tracking-tight">Available Jobs</h2>
                </div>
                {!data?.length || error || isError?
                    <Empty/>:
                    <Row gutter={[24, 24]}>
                        {data.map((job) => (
                            <Col xs={24} md={12} key={job.id}>
                                <JobsCard 
                                    key={job.jobId}
                                    title={job.title}
                                    dateCreated={job.dateCreated}
                                    roles={JSON.parse(job.roles)}
                                    description={job.description}
                                    jobGuid={job.jobId}
                                    isLoading={isLoading}
                                />
                            </Col>
                        ))}
                    </Row>
                }
            </Layout>
        </Layout>
    )
}
export default LandingPage