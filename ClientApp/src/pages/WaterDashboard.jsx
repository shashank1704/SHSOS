import React, { useState, useEffect } from 'react';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer, LineChart, Line } from 'recharts';

const WaterDashboard = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('/api/waterconsumption');
            const result = await response.json();
            setData(result);
        } catch (error) {
            console.error('Error fetching water data:', error);
        } finally {
            setLoading(false);
        }
    };

    if (loading) return <div className="p-4">Loading water data...</div>;

    return (
        <div className="space-y-6 animate-fade-in-up">
            <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-6">
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Total Consumption</h3>
                    <p className="text-3xl font-bold text-blue-600">
                        {data.reduce((acc, curr) => acc + (curr.unitsConsumedLiters || 0), 0).toLocaleString()} L
                    </p>
                </div>
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Average Daily</h3>
                    <p className="text-3xl font-bold text-blue-500">
                        {data.length ? Math.round(data.reduce((acc, curr) => acc + (curr.unitsConsumedLiters || 0), 0) / data.length).toLocaleString() : 0} L
                    </p>
                </div>
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Records</h3>
                    <p className="text-3xl font-bold text-gray-700">{data.length}</p>
                </div>
            </div>

            <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                <h3 className="text-lg font-semibold mb-4 text-gray-800">Consumption Trend</h3>
                <div className="h-80">
                    <ResponsiveContainer width="100%" height="100%">
                        <LineChart data={data}>
                            <CartesianGrid strokeDasharray="3 3" stroke="#eee" />
                            <XAxis dataKey="consumptionDate" />
                            <YAxis />
                            <Tooltip />
                            <Legend />
                            <Line type="monotone" dataKey="unitsConsumedLiters" stroke="#3b82f6" strokeWidth={2} activeDot={{ r: 8 }} name="Consumption (L)" />
                        </LineChart>
                    </ResponsiveContainer>
                </div>
            </div>

            <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                <h3 className="text-lg font-semibold mb-4 text-gray-800">Consumption by Source</h3>
                <div className="h-80">
                    <ResponsiveContainer width="100%" height="100%">
                        <BarChart data={data}>
                            <CartesianGrid strokeDasharray="3 3" stroke="#eee" />
                            <XAxis dataKey="usageCategory" />
                            <YAxis />
                            <Tooltip />
                            <Legend />
                            <Bar dataKey="unitsConsumedLiters" fill="#60a5fa" name="Consumption (L)" />
                        </BarChart>
                    </ResponsiveContainer>
                </div>
            </div>
        </div>
    );
};

export default WaterDashboard;
