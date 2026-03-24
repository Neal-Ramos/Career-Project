import { FilterOutlined, SearchOutlined } from "@ant-design/icons"
import { Badge, Button, Card, Col, Input, Row, Select, Space, Table } from "antd"
import { Option } from "antd/es/mentions"
import type { ColumnsType } from "antd/es/table"
import Text from "antd/es/typography/Text"
import Title from "antd/es/typography/Title"
import { useState } from "react"

function AdminApplications(){
    const [searchText, setSearchText] = useState("")
    const [statusFilter, setStatusFilter] = useState<string|null>()
    const [jobFilter, setJobFilter] = useState<string|null>()
    const jobTitles = [
        {label: "test", key: 1},
        {label: "test", key: 2},
        {label: "test", key: 3},
    ]
    const columns: ColumnsType = [

    ]
    const data: any = []

    return(
        <div style={{ padding: '24px' }}>
            <div style={{ marginBottom: '24px' }}>
                <Title level={2} style={{ margin: 0 }}>Applications</Title>
                <Text type="secondary">Review and manage candidate submissions across all active roles.</Text>
                <Card variant="borderless" style={{ marginBottom: '24px', borderRadius: '12px', boxShadow: '0 2px 8px rgba(0,0,0,0.05)' }}>
                    <Row gutter={[16, 16]} align="middle">
                        <Col xs={24} md={8}>
                            <Input
                                placeholder="Search by name or email..."
                                prefix={<SearchOutlined style={{ color: '#bfbfbf' }} />}
                                value={searchText}
                                onChange={e => setSearchText(e.target.value)}
                                allowClear
                            />
                        </Col>
                        <Col xs={12} md={5}>
                            <Select
                                placeholder="Filter by Job"
                                style={{ width: '100%' }}
                                onChange={value => setJobFilter(value)}
                                allowClear
                                suffixIcon={<FilterOutlined />}
                                value={jobFilter}
                                >
                                {jobTitles.map(title => (
                                    <Option key={title.key.toString()} value={title.label}>{title.label}</Option>
                                ))}
                            </Select>
                        </Col>
                        <Col xs={12} md={5}>
                            <Select
                                placeholder="Status"
                                style={{ width: '100%' }}
                                onChange={value => setStatusFilter(value)}
                                allowClear
                                value={statusFilter}
                            >
                                <Option value="Pending" key="1">Pending</Option>
                                <Option value="Accepted" key="2">Accepted</Option>
                                <Option value="Rejected" key="3">Rejected</Option>
                            </Select>
                        </Col>
                        <Col xs={24} md={6} style={{ textAlign: 'right' }}>
                            <Space>
                                <Badge count={data.length} overflowCount={999} color="#1677ff">
                                    <Text type="secondary" style={{ marginRight: 8 }}>Results</Text>
                                </Badge>
                                <Button onClick={() => {
                                    setSearchText('');
                                    setJobFilter(null);
                                    setStatusFilter(null);
                                }}>Reset</Button>
                            </Space>
                        </Col>
                    </Row>
                </Card>
                <Card variant="borderless" styles={{ body: { padding: 0 } }} style={{ borderRadius: '12px', overflow: 'hidden', boxShadow: '0 2px 8px rgba(0,0,0,0.05)' }}>
                    <Table
                        columns={columns}
                        dataSource={data}
                        pagination={{
                            total: data.length,
                            pageSize: 5,
                            showSizeChanger: true,
                            showTotal: (total) => `Total ${total} applicants`,
                            position: ['bottomRight']
                        }}
                        scroll={{ x: 800 }} // Ensures horizontal scrolling on small mobile devices
                    />
                </Card>
            </div>
        </div>
    )
}
export default AdminApplications