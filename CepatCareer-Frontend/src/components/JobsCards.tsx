import { Card } from "antd";
import { NormalizeDate } from "../helpers/NormalizeDate";

interface JobsCards {
    title: string
    dateCreated: string
    roles: {Name: string, Level: string}[]
    description: string
}

function JobsCard({title, dateCreated, roles, description}:JobsCards){
    console.log(roles)

    return(<Card className="min-w-2xs max-w-sm p-4">
        <div className="flex items-center justify-between mb-2">
            <h2 className="text-lg font-semibold">{title}</h2>
            <button className="px-3 py-1 text-sm bg-blue-600 text-white rounded hover:bg-blue-700">
            Apply Now
            </button>
        </div>

        <p className="text-sm text-gray-500 mb-3">
            Posted: {NormalizeDate(dateCreated)}
        </p>

        <div className="flex flex-wrap gap-2 mb-3">
            {
                roles.map(r => {
                    return <span key={r.Name} className="px-2 py-1 text-xs bg-blue-100 text-blue-700 rounded">
                        {r.Name}
                    </span>
                })
            }
        </div>

        <div>
            <h3 className="font-semibold">Description</h3>
            <p className="text-sm text-gray-600">
            {description}
            </p>
        </div>
    </Card>)
}
export default JobsCard