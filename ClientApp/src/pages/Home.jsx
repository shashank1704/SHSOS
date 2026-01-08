import React from 'react';
import { Droplets, Zap, Trash2 } from 'lucide-react';
import { Link } from 'react-router-dom';

const Home = () => {
    return (
        <div className="space-y-6">
            <div className="bg-white p-8 rounded-lg shadow-sm border border-gray-100 mb-8">
                <h1 className="text-3xl font-bold text-gray-900 mb-2">Welcome to SHSOS Dashboard</h1>
                <p className="text-gray-600">Smart Hospital Sustainability Operating System</p>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                <Link to="/water" className="block group">
                    <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100 transition duration-300 group-hover:shadow-md transform group-hover:-translate-y-1">
                        <div className="bg-blue-100 p-4 rounded-full w-16 h-16 flex items-center justify-center mb-4 text-blue-600">
                            <Droplets size={32} />
                        </div>
                        <h3 className="text-xl font-semibold text-gray-800 mb-2">Water Management</h3>
                        <p className="text-gray-500 text-sm">Monitor daily water consumption, analyze trends, and track usage across departments.</p>
                    </div>
                </Link>

                <Link to="/energy" className="block group">
                    <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100 transition duration-300 group-hover:shadow-md transform group-hover:-translate-y-1">
                        <div className="bg-yellow-100 p-4 rounded-full w-16 h-16 flex items-center justify-center mb-4 text-yellow-600">
                            <Zap size={32} />
                        </div>
                        <h3 className="text-xl font-semibold text-gray-800 mb-2">Energy Consumption</h3>
                        <p className="text-gray-500 text-sm">Track electricity usage, visualize peak hours, and specific consumption patterns.</p>
                    </div>
                </Link>

                <Link to="/waste" className="block group">
                    <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100 transition duration-300 group-hover:shadow-md transform group-hover:-translate-y-1">
                        <div className="bg-red-100 p-4 rounded-full w-16 h-16 flex items-center justify-center mb-4 text-red-600">
                            <Trash2 size={32} />
                        </div>
                        <h3 className="text-xl font-semibold text-gray-800 mb-2">Waste Management</h3>
                        <p className="text-gray-500 text-sm">Oversee waste generation, categorize types, and monitor recycling efficiency.</p>
                    </div>
                </Link>
            </div>
        </div>
    );
};

export default Home;
