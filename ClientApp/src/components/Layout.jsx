import React from 'react';
import { Outlet, Link, useLocation } from 'react-router-dom';
import { LayoutDashboard, Droplets, Zap, Trash2, Home } from 'lucide-react';

const Layout = () => {
    const location = useLocation();

    const isActive = (path) => {
        return location.pathname === path ? 'bg-gray-700' : 'hover:bg-gray-700';
    };

    return (
        <div className="flex h-screen bg-gray-100">
            {/* Sidebar */}
            <div className="w-64 bg-gray-900 text-white flex flex-col">
                <div className="p-4 text-xl font-bold flex items-center space-x-3 border-b border-gray-700">
                    <img src="/team_delta_logo.png" alt="Team Delta Logo" className="w-10 h-10 rounded-full" />
                    <div>
                        <div className="text-lg leading-tight">Team Delta</div>
                        <div className="text-xs text-blue-400 font-normal">SHSOS</div>
                    </div>
                </div>
                <nav className="flex-1 p-4 space-y-2">
                    <Link to="/" className={`flex items-center space-x-2 p-3 rounded transition ${isActive('/')}`}>
                        <Home size={20} />
                        <span>Home</span>
                    </Link>
                    <Link to="/water" className={`flex items-center space-x-2 p-3 rounded transition ${isActive('/water')}`}>
                        <Droplets size={20} />
                        <span>Water Management</span>
                    </Link>
                    <Link to="/energy" className={`flex items-center space-x-2 p-3 rounded transition ${isActive('/energy')}`}>
                        <Zap size={20} />
                        <span>Energy Consumption</span>
                    </Link>
                    <Link to="/waste" className={`flex items-center space-x-2 p-3 rounded transition ${isActive('/waste')}`}>
                        <Trash2 size={20} />
                        <span>Waste Management</span>
                    </Link>
                </nav>
                <div className="p-4 border-t border-gray-700 text-sm text-gray-400">
                    SHSOS v1.0
                </div>
            </div>

            {/* Main Content */}
            <div className="flex-1 overflow-auto">
                <header className="bg-white shadow p-4">
                    <h2 className="text-xl font-semibold text-gray-800">
                        {location.pathname === '/' && 'Home'}
                        {location.pathname === '/water' && 'Water Management'}
                        {location.pathname === '/energy' && 'Energy Consumption'}
                        {location.pathname === '/waste' && 'Waste Management'}
                    </h2>
                </header>
                <main className="p-6">
                    <Outlet />
                </main>
            </div>
        </div>
    );
};

export default Layout;
