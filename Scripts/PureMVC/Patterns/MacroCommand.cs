using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroCommand : Notifier, ICommand, INotifier
{
    private IList<Type> m_subCommands=new List<Type>();

    public MacroCommand()
    {
        this.InitalizeMacroCommand();
    }

    protected void AddSubCommand(Type commandType)
    {
        this.m_subCommands.Add(commandType);    
    }
    protected virtual void InitalizeMacroCommand()
    {
        
    }

    public void Execute(INotification notification)
    {
        while(this.m_subCommands.Count > 0)
        {
            Type type= this.m_subCommands[0];
            object obj2=Activator.CreateInstance(type);
            if (obj2 is ICommand)
            {
                ((ICommand)obj2).Execute(notification);
            }
            this.m_subCommands.RemoveAt(0);
        }
    }

}
