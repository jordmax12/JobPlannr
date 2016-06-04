class Navbar extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
         return (
                <nav id="mainNav" className="navbar navbar-default navbar-fixed-top">
                <div className="container-fluid">{/* Brand and toggle get grouped for better mobile display */}
                    <div className="navbar-header">
                    <button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span className="sr-only">Toggle navigation</span>
                        <span className="icon-bar" />
                        <span className="icon-bar" />
                        <span className="icon-bar" />
                    </button>
                    <a className="navbar-brand page-scroll" href="#page-top">JobPlannr</a>
                    </div>{/* Collect the nav links, forms, and other content for toggling */}
                    <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul className="nav navbar-nav navbar-right">{/*<li>
                        <a href="#about" className="page-scroll">About</a>
                        </li>
                        <li>
                        <a href="#services" className="page-scroll">Services</a>
                        </li>
                        <li>
                        <a href="#team" className="page-scroll">Team Members</a>
                        </li>
                        <li>
                        <a href="#contact" className="page-scroll">Contact</a>
                        </li>*/}
                        <li>
                        <a href="#" className="page-scroll nav-inverse" data-toggle="modal" data-target="#signout">Logout</a>
                        </li>
                    </ul>
                    </div>{/* /.navbar-collapse */}
                </div>{/* /.container-fluid */}
                </nav>
        );
    };
}
