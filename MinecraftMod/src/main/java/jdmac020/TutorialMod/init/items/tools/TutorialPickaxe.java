package jdmac020.TutorialMod.init.items.tools;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item.ToolMaterial;
import net.minecraft.item.ItemPickaxe;

public class TutorialPickaxe extends ItemPickaxe
{

	public TutorialPickaxe(ToolMaterial material, String name) 
	{
		super(material);
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialTools);
	}
	
}
