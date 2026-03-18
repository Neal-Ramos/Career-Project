import { Col, Empty, Layout, Pagination, Row } from "antd"
import JobsCard from "../components/JobsCards"
import LandingHero from "../components/LandingHero"
import { useJobs } from "../Hooks/useJobs"
import { Footer } from "antd/es/layout/layout"
import { useRef, useState } from "react"

function LandingPage(){
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(8)
    const { data, isLoading, isError, error } = useJobs(page, pageSize)
    const jobSection = useRef<HTMLDivElement>(null)

    return(
        <Layout>
            <LandingHero/>
            <Layout className="max-w-4xl! mx-auto! px-6! pt-10! w-full! min-h-dvh!" ref={jobSection}>
                <div className="mb-10 text-center">
                    <h2 className="text-3xl font-black text-slate-900 tracking-tight">Available Jobs</h2>
                </div>
                {!data?.jobs.length || error || isError?
                    <Empty/>:
                    <Row gutter={[24, 24]}>
                        {data.jobs.map((job) => (
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
                <Pagination
                    responsive={true}
                    current={page} 
                    total={data?.totalRecords} 
                    pageSize={pageSize} 
                    showSizeChanger
                    pageSizeOptions={['4', '8', '12', '20']}
                    className="justify-center py-4!"
                    onChange={(page, pageSize) => {
                        setPage(page)
                        setPageSize(pageSize)
                        jobSection.current?.scrollIntoView({
                            behavior: "smooth"
                        })
                    }}
                />
            </Layout>
            <Footer className="bg-[#001529]!">
            </Footer>
        </Layout>
    )
}
export default LandingPage