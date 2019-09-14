using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Jonathan Jacildo
//CIS - Paragraph Anaysis Problem

namespace Paragraph_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            string quote = "Impossible is just a big word thrown around by small men who find it easier to live in the world they've been given than to explore the power they have to change it." +
                               "Impossible is not a fact." +
                               "It's an opinion.Impossible is not a declaration." +
                               "It's a dare.Impossible is potential." +
                               "Impossible is temporary." +
                               "Impossible is nothing.";
            string problem = "Tristique senectus et netus et malesuada fames ac." + 
                             "Semper auctor neque vitae tempus." + 
                             "Cras pulvinar mattis nunc sed blandit libero volutpat sed cras." + 
                             "Feugiat in ante metus dictum at tempor commodo ullamcorper a." + 
                             "Semper viverra nam libero justo laoreet sit amet cursus sit." + 
                             "Varius morbi enim nunc faucibus a." + 
                             "Tempor nec feugiat nisl pretium fusce id velit ut tortor." + 
                             "Ultricies tristique nulla aliquet enim." + 
                             "Nulla facilisi cras fermentum odio eu." + 
                             "Sed ullamcorper morbi tincidunt ornare massa eget egestas purus viverra." + 
                             "Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate sapien nec." + 
                             "Lorem sed risus ultricies tristique nulla aliquet enim tortor at." + 
                             "Consectetur adipiscing elit pellentesque habitant morbi tristique senectus." + 
                             "Diam maecenas ultricies mi eget mauris pharetra et.";
            ParagraphAnalysis txt = new ParagraphAnalysis(problem);

            foreach(string s in txt.Results())
            {
                Console.WriteLine(s);
            }
           
            Console.ReadKey();

        }
            
    }
}
