import React, { useState, useEffect } from 'react';
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

const EnergyDashboard = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('/api/energyconsumption');
            const result = await response.json();
            setData(result);
        } catch (error) {
            console.error('Error fetching energy data:', error);
        } finally {
            setLoading(false);
        }
    };

    if (loading) return <div className="p-4">Loading energy data...</div>;

    return (
        <div className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-6">
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Total Energy Used</h3>
                    <p className="text-3xl font-bold text-yellow-600">
                        {data.reduce((acc, curr) => acc + (curr.unitsConsumedkWh || 0), 0).toLocaleString()} kWh
                    </p>
                </div>
                <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                    <h3 className="text-gray-500 text-sm font-medium">Total Cost</h3>
                    <p className="text-3xl font-bold text-green-600">
                        ${data.reduce((acc, curr) => acc + (curr.totalCost || 0), 0).toLocaleString()}
                    </p>
                </div>
            </div>

            <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100">
                <h3 className="text-lg font-semibold mb-4 text-gray-800">Energy Consumption Over Time</h3>
                <div className="h-80">
                    <ResponsiveContainer width="100%" height="100%">
                        <AreaChart data={data}>
                            <CartesianGrid strokeDasharray="3 3" />
                            <XAxis dataKey="consumptionDate" />
                            <YAxis />
                            <Tooltip />
                            <Area type="monotone" dataKey="unitsConsumedkWh" stroke="#eab308" fill="#fef08a" name="Energy (kWh)" />
                        </AreaChart>
                    </ResponsiveContainer>
                </div>
            </div>
        </div>
    );
};

export default EnergyDashboard;
