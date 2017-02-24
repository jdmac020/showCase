package jdmac020.TutorialMod.init.items.tools;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.ItemAxe;

public class TutorialAxe extends ItemAxe
{

	public TutorialAxe(ToolMaterial material, String name) 
	{
		super(material,3.0F,3.0F);
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialTools);
	}
	
}
