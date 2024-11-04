<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Libmanagementsystem.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
      @import url('https://fonts.googleapis.com/css2?family=Orbitron:wght@400..900&family=Space+Grotesk:wght@300..700&display=swap');

      /* Background styling for the homepage */
      .home-background {
         background-image: url('imgs/background.jpg');
         background-size: cover;
         background-position: center;
         position: relative;
         width: 100%;
         height: 100vh;
         display: flex;
         align-items: center;
         justify-content: center;
         color: #ffffff;
         text-align: center;
         overflow: hidden;
      }

      /* Centered overlay with margins and rounded corners */
      .overlay {
         position: absolute;
         top: 15%;
         left: 15%;
         width: 70%;
         height: 65%;
         background-color: rgba(0, 0, 0, 0.6);
         z-index: 1;
         border-radius: 20px; /* Rounded corners */
         pointer-events: none; /* Ensures it doesn’t block clicks */
      }

      /* Text style within the content */
      .home-content {
         position: relative;
         z-index: 2;
      }

      .home-content h1 {
         font-size: 3em;
         font-weight: bold;
         font-family: "Space Grotesk", sans-serif; /* Apply font here */
      }

      .home-content p {
         font-size: 1.5em;
         font-family: "Space Grotesk", sans-serif; /* Apply font here */
         overflow: hidden; /* Ensures no overflow during typing animation */
         white-space: nowrap; /* Keeps text on a single line */
         border-right: .15em solid orange; /* Typing cursor effect */
         animation: typing 6s steps(40, end) forwards, blink-caret 0.75s step-end infinite; /* Typing animation */
      }

      /* Typing animation keyframes */
      @keyframes typing {
         from { width: 0; }
         to { width: 100%; }
      }

      /* Caret blinking effect */
      @keyframes blink-caret {
         from, to { border-color: transparent; }
         50% { border-color: orange; }
      }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="home-background">
      <div class="overlay"></div>
      <div class="home-content">
         <h1>Librix - An Advanced Library managemet system </h1>
         <p>Features: Book Inventory, Member Management, Author Management, Publisher Management, Book Issuing</p>
      </div>
   </div>
</asp:Content>
