package jdmac020.TutorialMod.init.items.tools;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.ItemSpade;

public class TutorialShovel extends ItemSpade
{

	public TutorialShovel(ToolMaterial material, String name) 
	{
		super(material);
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialTools);
	}
	
}
