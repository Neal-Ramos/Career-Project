import { Button, Card, Col, DatePicker, Divider, Form, Input, Layout, Row } from "antd"
import Text from "antd/es/typography/Text"
import Title from "antd/es/typography/Title"
import { useParams } from "react-router-dom"
import FileRequirements from "../components/FileReuirements"
import { useJobsById } from "../Hooks/useJobs"

function ApplyJob(){
    const { jobGuid } = useParams()
    const { data, isLoading, isError, error } = useJobsById(jobGuid || "")
    const [form] = Form.useForm();

    const onFinish = () => {
        
    };

    return(
        <Layout>
            <div className="bg-linear-to-b! from-[#001529]! to-[#001d3d]! text-white! pt-16! pb-24! px-6! text-center!">
                <Title level={1} className="text-white! mb-2!">
                    Complete Your <span className="text-blue-400!">Application</span>
                </Title>
                <Text className="text-slate-400! text-base!">
                    Join top-tier companies globally. Please provide your academic and professional details.
                </Text>
            </div>
            
            <div className="flex! justify-center! px-4!">
                <Card className="w-full! max-w-4xl! rounded-2xl! shadow-2xl! -mt-16! border-none!">
                    <Form
                        form={form}
                        layout="vertical"
                        onFinish={onFinish}
                        size="large"
                        className="w-full!"
                    >
                        <div className="border-l-4! border-blue-500! pl-3! mb-5! font-bold! text-lg! uppercase! tracking-wider! text-slate-700!">
                            Personal Information
                        </div>
                        <Row gutter={16}>
                            <Col xs={24} md={8}>
                                <Form.Item label="First Name" name="firstName" rules={[{ required: true }]}>
                                <Input placeholder="John" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                            <Col xs={24} md={8}>
                                <Form.Item label="Middle Name" name="middleName">
                                <Input placeholder="Quincy" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                            <Col xs={24} md={8}>
                                <Form.Item label="Last Name" name="lastName" rules={[{ required: true }]}>
                                <Input placeholder="Doe" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                        </Row>
                        <Row gutter={16}>
                            <Col xs={24} md={12}>
                                <Form.Item 
                                label="Email Address" 
                                name="email" 
                                rules={[{ required: true, type: 'email' }]}
                                >
                                <Input placeholder="john.doe@example.com" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                            <Col xs={24} md={12} className="">
                                <Form.Item
                                label="Contact Number" 
                                name="contactNumber" 
                                rules={[{ required: true }]}
                                >
                                <Input placeholder="+63 9000000000" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                        </Row>

                        <Divider className="my-6!"/>
                        <div className="border-l-4 border-blue-500 pl-3 mb-5 font-bold text-lg uppercase tracking-wider text-slate-700">
                            Education Background
                        </div>
                        <Row gutter={16}>
                            <Col xs={24} md={12}>
                                <Form.Item label="University Name" name="universityName" rules={[{ required: true }]}>
                                <Input placeholder="State University" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                            <Col xs={24} md={6}>
                                <Form.Item label="Degree" name="degree" rules={[{ required: true }]}>
                                <Input placeholder="B.S. Computer Science" className="rounded-lg!" />
                                </Form.Item>
                            </Col>
                            <Col xs={24} md={6}>
                                <Form.Item label="Graduation Year" name="graduationYear" rules={[{ required: true }]}>
                                <DatePicker picker="year" className="w-full! rounded-lg!" />
                                </Form.Item>
                            </Col>
                        </Row>

                        <Divider className="my-6!" />
                        <div className="border-l-4 border-blue-500 pl-3 mb-5 font-bold text-lg uppercase tracking-wider text-slate-700">
                            Required Documents
                        </div>
                        <FileRequirements files={data?.fileRequirements ? JSON.parse(data.fileRequirements) : []}/>
                        <div className="mt-10!">
                        <Button 
                            type="primary" 
                            htmlType="submit" 
                            block 
                            loading={isLoading}
                            className="h-12! text-lg! font-bold! rounded-lg! shadow-lg! bg-blue-600! hover:bg-blue-700! border-none!"
                        >
                            Submit Full Application
                        </Button>
                        </div>
                    </Form>
                </Card>
            </div>
        </Layout>
    )
}
export default ApplyJob