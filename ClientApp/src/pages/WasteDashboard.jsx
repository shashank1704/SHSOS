import React, { useState, useEffect } from 'react';
import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer, Legend } from 'recharts';

const WasteDashboard = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('/api/wastemanagement');
            const result = await response.json();
            setData(result);
        } catch (error) {
            console.error('Error fetching waste data:', error);
        } finally {
            setLoading(false);
        }
    };

    const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042', '#8884d8'];

    // Aggregate data by waste type
    const aggregatedData = data.reduce((acc, curr) => {
        const existing = acc.find(item => item.name === curr.wasteType);
        if (existing) {
            existing.value += curr.wasteWeightKg || 0;
        } else {
            acc.push({ name: curr.wasteType, value: curr.wasteWeightKg || 0 });
        }
        return acc;
    }, []);

    if (loading) return <div className="p-4">Loading waste data...</div>;

    return (
        <div className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-6">
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Total Waste Generated</h3>
                    <p className="text-3xl font-bold text-red-600">
                        {data.reduce((acc, curr) => acc + (curr.wasteWeightKg || 0), 0).toLocaleString()} kg
                    </p>
                </div>
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Recycling Rate</h3>
                    <p className="text-3xl font-bold text-green-600">
                        {/* Placeholder calculation - would need real recycling status */}
                        N/A
                    </p>
                </div>
            </div>

            <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                <h3 className="text-lg font-semibold mb-4 text-gray-800">Waste Composition</h3>
                <div className="h-80 flex justify-center">
                    <ResponsiveContainer width="100%" height="100%">
                        <PieChart>
                            <Pie
                                data={aggregatedData}
                                cx="50%"
                                cy="50%"
                                labelLine={false}
                                label={({ name, percent }) => `${name} ${(percent * 100).toFixed(0)}%`}
                                outerRadius={120}
                                fill="#8884d8"
                                dataKey="value"
                            >
                                {aggregatedData.map((entry, index) => (
                                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                                ))}
                            </Pie>
                            <Tooltip />
                            <Legend />
                        </PieChart>
                    </ResponsiveContainer>
                </div>
            </div>
        </div>
    );
};

export default WasteDashboard;
