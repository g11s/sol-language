using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenerateAst
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: generate_ast <output directory>");
                Environment.Exit(64);
            }

            string outputDir = args[0];

            List<string> files = new List<string>
            {
                "Binary   : Expression left, Token op, Expression right",
                "Grouping : Expression expression",
                "Literal  : Object value",
                "Unary    : Token operator, Expression right"
            };

            foreach (string file in files)
            {
                string className = file.Split(":")[0].Trim();
                DefineAst(outputDir, className, file);
            }

        }

        private static void DefineAst(string outputDir, string baseName, string type)
        {
            string path = $"{outputDir}/{baseName}.cs";

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // The AST classes.
            string className = type.Split(":")[0].Trim();
            string fields = type.Split(":")[1].Trim();

            StreamWriter writer = new StreamWriter(path, true, Encoding.ASCII);
            writer.WriteLine("namespace Domain.Entities");
            writer.WriteLine("{");
            writer.WriteLine($"    public class {baseName}");
            writer.WriteLine("    {");

            DefineType(writer, baseName, className, fields);

            writer.WriteLine("}");
            writer.Close();
        }

        private static void DefineType(StreamWriter writer, string baseName, string className, string fieldList)
        {
            string[] fields = fieldList.Split(", ");

            // Fields.
            foreach (string field in fields)
            {
                writer.WriteLine("        private " + field + ";");
            }

            // Constructor
            writer.WriteLine("");
            writer.WriteLine("        public " + className + "(" + fieldList + ") {");

            // Store parameters in fields.
            
            foreach (string field in fields)
            {
                string name = field.Split(" ")[1];
                writer.WriteLine("            this." + name + " = " + name + ";");
            }

            writer.WriteLine("        }");

            

            writer.WriteLine("    }");
        }
    }
}
