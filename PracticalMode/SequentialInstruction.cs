using System.Collections.Generic;
using UnityEngine;

public class SequentialInstruction 
{
    public Stack<string> disassemblyStack;
    private string selectDetail;

    public void GetInstruction(string selectDetail)
    {
        this.selectDetail = selectDetail;

        GeneratedStack(InstructionSelect());
    }

    private void GeneratedStack(List<string> instruction)
    {
        disassemblyStack = new Stack<string>();
        instruction.Reverse();

        foreach (var item in instruction)
        {
            disassemblyStack.Push(item);
        }
    }

    private List<string> InstructionSelect()
    {
        List<string> instruction;

        switch (selectDetail)
        {
            case "compressor":
                instruction = new List<string>(){"input_pipe_top", "output_pipe_top", 
                        "input_turbine_top", "case_4_steps_top", "case_5_steps_top" ,
                        "case_8_steps_top", "annalar_combustion_chamber_top", 
                        "turbine_casing_top","end_turbine", "shaft", "compressor"
                        };
                break;

            default:
                instruction = new List<string>();
                break;
        }
        
        return instruction;
    }
}