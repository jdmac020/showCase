package jdmac020.TutorialMod.init.items.tools;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item;
import net.minecraft.item.ItemHoe;

public class TutorialHoe extends ItemHoe 
{

	public TutorialHoe(ToolMaterial material, String name) 
	{
		super(material);
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialTools);
	}

}
